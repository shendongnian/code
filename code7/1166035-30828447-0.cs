    var array = Enumerable.Range(1,15).ToArray();
    //First get all image from db
    var images = from t in dbContext.ImageAds
        where array.Contains(t.Id)
        select t.image;
    //create thread for delay to prevent freezing screen
    Task.Factory.StartNew(() =>
    {
        while (true)
        {
            foreach (var img in array)
            {
                // call method in ui thread
                this.Invoke((MethodInvoker)delegate //this: form control
                {
                    pictureBox1.Image = ByteArrayToImage(img.ToArray());
                });
                Thread.Sleep(1000);                        
            }
        }
    });
