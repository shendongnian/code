    private class Foo
    {
         public List<List<List<double>>> coordinates { get; set; }
    }
    
     var json = @"{
                     coordinates: [
                                    [
                                        [-3.213338431720785, 55.940382588499197],
                                        [-3.213340490487523, 55.940381867350276],
                                        [-3.213340490487523, 55.940381867350276],
                                        [-3.213814166228732, 55.940215021175085],
                                        [-3.21413960035129, 55.940100842843712]
                                    ]
                                ]
                        }";
    var result = JsonConvert.DeserializeObject<Foo>(json);
