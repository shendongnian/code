    private void StubCallerToThrowNotFoundException(string iprange)
        {
            var response = new Mock<HttpWebResponse>();
            response.Setup(c => c.StatusCode).Returns(HttpStatusCode.NotFound);
            mocker.Setup<ICaller>(x => x.GetResponseAsync(It.Is<string>(p => !p.Contains(iprange))))
                .Throws(new WebException("Some test exception", null, WebExceptionStatus.ProtocolError, response.Object));
        }
