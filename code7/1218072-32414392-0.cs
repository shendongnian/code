    var count = list.Aggregate(new { Integer = 0, Hi = 0, Hello = 0, (c, s) =>
                    {
                        int c1 = c.Integer, 
                            c2 = c.Hi, 
                            c3 = c.Hello,  
                            n;
                        if (int.TryParse(s, out n)) 
                            c1++;
                        else if (s == "Hi") 
                            c2++;
                        else if (s == "Hello") 
                            c3++;
                        return new { 
                            Integer = c1, 
                            Hi = c2, 
                            Hello = c3, 
                                        };
                    });
