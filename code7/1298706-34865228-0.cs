        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine(e.Data);
            if (Target != null)
                Target.Invoke( () => {Target.Items.Add(e.Message);});
            Send("Received");
        }
