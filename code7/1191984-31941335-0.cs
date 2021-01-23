    // define time series item type
    struct Tick
    {
        public Time Time;
        public double Price;
        public int Volume;
    }
     // create file and write values
    using (var tf = TeaFile<Tick>.Create("acme.tea"))
    {
        tf.Write(new Tick { Price = 5, Time = DateTime.Now, Volume = 700 });
        tf.Write(new Tick { Price = 15, Time = DateTime.Now.AddHours(1), Volume = 1700 });
        // ...
    }
    // sum the prices of all items in the file
    using (var tf = TeaFile<Tick>.OpenRead("acme.tea"))
    {
        return tf.Items.Sum(item => item.Price);
    }
