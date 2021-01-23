      Assert.That(new Record { P1 = 1.0, P2 = 100.0, },
        IsAlternatively.EqualTo(new Record { P1 = 1.0, P2 = 99.99999999, }).Within(.0001)
        );
      Assert.That(new Record { P1 = 1.0, P2 = 100.0, },
        IsAlternatively.EqualTo(new Record { P1 = 1.0, P2 = 100.0, }).Within(.0001)
        );
      Assert.That(new Record { P1 = 1.0, P2 = 100.0, },
        IsAlternatively.EqualTo(new Record { P1 = 1.0, P2 = 66.6, }).Within(.0001)
        );
