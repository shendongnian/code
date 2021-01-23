    mock.Setup(p => p.DoSomething(It.IsAny<string>(), It.IsAny<Action<string>>()))
        .CallBack((string p1, Action<string> p2) =>
        {
            // your code (for example Asserts) here,
            // use p2
        });
