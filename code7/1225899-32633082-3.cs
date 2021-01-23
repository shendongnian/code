        class Data : IThisfieldSupported
        {
            string Thisfield { get;set; }
            int Id { get;set; }
        }
        ...
        var data = new Data[10];
        var result = FilterBySomething(data);
