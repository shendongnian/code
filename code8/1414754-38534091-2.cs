    public class EditViewShowerDecorator<TEntity> : IEditView<TEntity>
    {
        private readonly Func<IEditView<TEntity>> viewCreator;
        public EditViewShowerDecorator(Func<IEditView<TEntity>> viewCreator)
        {
            this.viewCreator = viewCreator;
        }
        public void EditEntity(TEntity entity)
        {
            // get view from container
            var view = this.viewCreator.Invoke();
            // initview with information
            view.EditEntity(entity);
            using (var form = (Form)view)
            {
                // show the view
                form.ShowDialog();
            }
        }
    }
