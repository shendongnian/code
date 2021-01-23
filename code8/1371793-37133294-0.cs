    var input = new[] {
        new { Col1 =1, Col2= 2, Col3 = 1, Col4 = 1.5m},
        new { Col1 =1, Col2= 1, Col3 = 1, Col4 = 1.8m},
        new { Col1 =1, Col2= 2, Col3 = 1, Col4 = 2.5m},
        new { Col1 =1, Col2 =1, Col3 = 1, Col4 = 3m},
        new { Col1 =3, Col2 =1, Col3 = 4, Col4=  5m}
        };
    var result = input.GroupBy(x => new { x.Col1, x.Col2, x.Col3 })
            .Select(x => new
            {
                Col1 = x.Key.Col1,
                Col2 = x.Key.Col2,
                Col3 = x.Key.Col3,
                Col4 = x.Sum(y => y.Col4)
            });
