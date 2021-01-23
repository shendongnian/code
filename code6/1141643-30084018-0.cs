    [TestFixture]
    public class TestPdfPagePresenter
    {
        [Test]
        public void TestOnPageLoadInvalidQuerystringRunsRedirect()
        {
            var qstringval = new Mock<IPdfPageVisitor<bool>>();
            var spackageval = new Mock<IPdfPageVisitor<bool>>();
            var watermarkgen = new Mock<IPdfPageVisitor<byte[]>>();
    
            var fac = new Mock<IPdfPageVisitorAbstractFactory>();
            fac.Setup(f => f.QueryStringValidatorFactory()).Returns(() => qstringval.Object);
            fac.Setup(f => f.ServicePackageValidatorFactory()).Returns(() => spackageval.Object);
            fac.Setup(f => f.WatermarkStreamGeneratorFactory()).Returns(() => watermarkgen.Object);
    
    
            var view = new Mock<IPdfPageView>();
            view.Setup(v => v.Accept(qstringval.Object)).Returns(false);
            view.Setup(v => v.Accept(spackageval.Object)).Returns(true);
            view.Setup(v => v.Accept(watermarkgen.Object)).Returns(new byte[0]);
    
            Assert.DoesNotThrow(() =>
            {
                var presenter = new PdfPagePresenter(view.Object, fac.Object);
                presenter.OnPageLoad();
                view.Verify(v => v.RespondRedirect("Somepage.aspx"));
                view.Verify(v => v.RespondWrite("Cannot find the service package in our system."), Times.Never);
                view.Verify(v => v.RespondBinaryWrite(watermarkgen.Object.Result(), "application/pdf"), Times.Never);
            });
        }
    
        [Test]
        public void TestOnPageLoadInvalidServicePackageRunsWrite()
        {
            var qstringval = new Mock<IPdfPageVisitor<bool>>();
            var spackageval = new Mock<IPdfPageVisitor<bool>>();
            var watermarkgen = new Mock<IPdfPageVisitor<byte[]>>();
    
            var fac = new Mock<IPdfPageVisitorAbstractFactory>();
            fac.Setup(f => f.QueryStringValidatorFactory()).Returns(() => qstringval.Object);
            fac.Setup(f => f.ServicePackageValidatorFactory()).Returns(() => spackageval.Object);
            fac.Setup(f => f.WatermarkStreamGeneratorFactory()).Returns(() => watermarkgen.Object);
    
    
            var view = new Mock<IPdfPageView>();
            view.Setup(v => v.Accept(qstringval.Object)).Returns(true);
            view.Setup(v => v.Accept(spackageval.Object)).Returns(false);
            view.Setup(v => v.Accept(watermarkgen.Object)).Returns(new byte[0]);
    
            Assert.DoesNotThrow(() =>
            {
                var presenter = new PdfPagePresenter(view.Object, fac.Object);
                presenter.OnPageLoad();
                view.Verify(v => v.RespondRedirect("Somepage.aspx"), Times.Never);
                view.Verify(v => v.RespondWrite("Cannot find the service package in our system."));
                view.Verify(v => v.RespondBinaryWrite(watermarkgen.Object.Result(), "application/pdf"), Times.Never);
            });
        }
    
        [Test]
        public void TestOnPageLoadValidRunsBinaryWrite()
        {
            var qstringval = new Mock<IPdfPageVisitor<bool>>();
            var spackageval = new Mock<IPdfPageVisitor<bool>>();
            var watermarkgen = new Mock<IPdfPageVisitor<byte[]>>();
    
            var fac = new Mock<IPdfPageVisitorAbstractFactory>();
            fac.Setup(f => f.QueryStringValidatorFactory()).Returns(() => qstringval.Object);
            fac.Setup(f => f.ServicePackageValidatorFactory()).Returns(() => spackageval.Object);
            fac.Setup(f => f.WatermarkStreamGeneratorFactory()).Returns(() => watermarkgen.Object);
    
            var returnbytes = new byte[0];
            var view = new Mock<IPdfPageView>();
            view.Setup(v => v.Accept(qstringval.Object)).Returns(true);
            view.Setup(v => v.Accept(spackageval.Object)).Returns(true);
            view.Setup(v => v.Accept(watermarkgen.Object)).Returns(returnbytes);
    
            Assert.DoesNotThrow(() =>
            {
                var presenter = new PdfPagePresenter(view.Object, fac.Object);
                presenter.OnPageLoad();
                view.Verify(v => v.RespondRedirect("Somepage.aspx"), Times.Never);
                view.Verify(v => v.RespondWrite("Cannot find the service package in our system."), Times.Never);
                view.Verify(v => v.RespondBinaryWrite(returnbytes, "application/pdf"));
            });
        }
    
    }
