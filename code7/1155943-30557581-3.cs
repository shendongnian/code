        public class CustomCheckbox : CheckBox, ICustomControl
        {
            //..
            public void Accept(ControlVisitor visitor)
            {
                visitor.Visit(this);
            }
            //..
        }
