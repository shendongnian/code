    private void DoStuffCast(Control obj) // whatever the base type is
    {
        var btn = obj as Button;
        if (btn != null)
        {
            btn.Content = "Foo";
            Console.WriteLine("Button!");
            return;
        }
        vat tb = obj as Textbox;
        if (tb != null)
        {
            tb.Text = "Bar";
            Console.WriteLine("Textbox!");
            return;
        }
    }
