    iPaymentMock.SetupSequence(counter => counter.ProcessPayment
        (
             It.IsAny<Context>(),
             It.IsAny<PreregisteredAccountSpec>(),  
             It.IsAny<Guid>())
        )
        .Returns(paymentSpecificationResponse)
        .Throws(new Exception());
