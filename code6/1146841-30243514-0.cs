        Queue<XElement> puppiesQueue = new Queue<XElement>();
        void LoadPuppies()
        {
            XDocument puppies = XDocument.Load(@"C:\puppies.xml");
            foreach (XElement puppie in puppies.Descendants("Row"))
                puppiesQueue.Enqueue(puppie);
        }
        void Button_Click()
        {
            //Each time you click the button, it will return you the next puppie in the queue.
            PuppyName = puppiesQueue.Dequeue().Element("puppyName").Value;
        }
