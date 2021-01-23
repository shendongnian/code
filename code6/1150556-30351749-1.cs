    public class SomethingInThePresentationLayer
    {
        public void SomeMethod()
        {
            var businessObject = new SomethingInTheBusinessLayer();
            var result = businessObject.Validate();
            pageElement.Text = result;
        }
    }
    public class SomethingInTheBusinessLayer
    {
        public string Validate()
        {
            return "This is the text";
        }
    }
