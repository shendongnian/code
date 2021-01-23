    using System.Windows.Forms.Design;
    public class MyLabelDesigner : ControlDesigner
    {
        public override SelectionRules SelectionRules
        {
            get
            {
                return (base.SelectionRules & ~(SelectionRules.BottomSizeable | 
                                                SelectionRules.TopSizeable));
            }
        }
    }
