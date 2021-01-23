    var result = a.GroupJoin(b,
                             a0 => a0.Foo,
                             b0 => b0.Foo,
                             (a0, bs) =>
                             {
                                 var bArr = bs.ToArray();
                                 return new
                                        {
                                            Foo = a0.Foo,
                                            Baz = a0.Baz,
                                            Code = bArr.Length == 0 ? "" : bArr[0].Code,
                                            Bars = bArr.Select(b1 => new {b1.Value, b1.Code})
                                        };
                             }).ToArray();
