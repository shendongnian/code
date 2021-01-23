    public class FormFactory : IFormFactory
    {
        private readonly Container container;
        public FormFactory(Container container) {
            this.container = container;
        }
        public TForm CreateFormFor<TForm, TEntity>(TEntity entity) 
            where TForm : Form, IForm<TEntity> {
            var form = this.container.GetInstance<TForm>();
            form.Entity = entity;
            return form;
        }
    }
