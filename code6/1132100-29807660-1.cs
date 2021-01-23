        private delegate void MyDelegate();
        private void button1_Click(object sender, EventArgs e)
        {
            prepare(delegate
            {
                Debug.WriteLine("test1");
            });
        }
        private void prepare(MyDelegate d)
        {
            Debug.WriteLine("Prepare");
            //Maybe invoke the delegate, maybe not yet
            //     d.Invoke();
        }
