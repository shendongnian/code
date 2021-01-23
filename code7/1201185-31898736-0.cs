    namespace Blah{
        public static class FormInstances {
            public static Login LoginForm;
        }
    
        public class Misc{
            FormInstances.LoginForm.txtTest.text = "test";
        }
    }
