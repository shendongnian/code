    public class TypeCustomization<T> : ICustomization
    {
        private List<Action<T>> actions;
        public TypeCustomization()
        {
            this.actions = new List<Action<T>>();
        }
        public void Customize(IFixture fixture)
        {
            fixture.Customize<T>(
                cmp =>
                    {
                        return this.actions.Aggregate<Action<T>, IPostprocessComposer<T>>(cmp, (current, next) => current.Do(next));
                    });
        }
        public TypeCustomization<T> With(string propertyName, object value)
        {
            this.actions.Add(obj => obj.SetProperty(propertyName, value));
            return this;
        }
    }
