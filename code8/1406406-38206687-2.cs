    using System.Windows.Forms.Design;
    public class MyLabelDesigner : ControlDesigner
    {
        public override SelectionRules SelectionRules
        {
            get
            {
                if (this.Control.AutoSize)
                    return (base.SelectionRules &
                           ~(SelectionRules.BottomSizeable | SelectionRules.TopSizeable));
                else
                    return base.SelectionRules;
            }
        }
    }
