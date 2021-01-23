    List<Conta> contas = new List<Conta>();
    contas.Add(new Conta { ID = 1, Saldo = 30 });
    contas.Add(new Conta { ID = 2, Saldo = 50 });
    contas.Add(new Conta { ID = 3, Saldo = 100 });
    var result = contas.MaxBy(x => x.Saldo);
    Console.WriteLine(result.ID);
