    [Designer(typeof(BookshelfControl.Designer))]
    public class BookshelfControl : Control
    {
        internal class Designer : ControlDesigner
        {
            private IComponent component;
            public override void Initialize(IComponent component)
            {
                base.Initialize(component);
                this.component = component;
            }
            //
            // Critical step getting the designer to 'cache' related object
            // instances to be copied with this BookshelfControl instance:
            //
            public override System.Collections.ICollection AssociatedComponents
            {
                get
                {
                    return ((BookshelfControl)this.component).Books;
                }
            }
        }
        [Editor(typeof(ArrayEditor), typeof(UITypeEditor)),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Book[] Books { get; set; }
        ...
    }
