	class Box
    {
        public static Action<String> Echo { get; set; }
        static Box() { Echo = (String s) => {Console.WriteLine(s);};}
        public void DoSomething()
        {
            Box.Echo.Invoke(DateTime.Now.ToString());
        }
    }
	
...
	
            Box obj = new Box();
            obj.DoSomething();
            Box.Echo = (String s) => { MessageBox.Show(s); };
            obj.DoSomething();
