    imports System.Windows.Forms;
        public class AnswerForm
            {
                public RadioButton[] rbuttons { get; set; }
                public CheckBox[] checkboxes { get; set; }    
            }
        
        static class FormExtension
        {
            public static void Visible(this Forms[] elem, bool state)
            {
                foreach (var item in elem)
                    item.Visible = state;
            }
        }
