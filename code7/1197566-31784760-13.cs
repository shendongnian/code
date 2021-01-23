    static void Main(string[] args)
        {
            var bindableList = new BindableList<Bindable>();
            var binderList = new BinderList<BinderElement>()
            {
                new BinderElement(),
                new BinderElement()
            };
            binderList.DataContextList = bindableList;
            binderList.AddBindingRule("Description", "Description");
            bindableList.Add(new BindableElement());
            bindableList.Add(new BindableElement());
            ((BindableElement)bindableList[1]).Description = "This should arrive in BinderElement Description property";
            Console.WriteLine(binderList[1].Description);
            Console.ReadLine();
        }
