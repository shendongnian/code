    public class Parent
    {
        public void CreateChild()
        {
            Child childNew = new Child(this); //here you give over the parents reverence
        }
        public void SaveStuff(int number)
        {
            //here you can save the number
        }
    }
    class Child
    {
        private Parent parent;
        public Child(Parent parent)
        {
            this.parent = parent;
        }
        public void PressOkButton()
        {
            this.parent.SaveStuff(4); //here you are doing the callback
        }
    }
