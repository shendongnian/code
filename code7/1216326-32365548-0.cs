        void AddItemToPanel()
        {
            //Creating a new temporary item.
            Button TempBt = new Button();
            TempBt.Text = "Hello world!";
            //Adding the button to our itemlist.
            BtList.Add(TempBt);
            //Adding the event to our button.
            //Because the added item is always the last we use:
            PanelForButtons.Controls.Add(BtList.Last());
            BtList.Last().Click += MyButtonClicked;
        }
