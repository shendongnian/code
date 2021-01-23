       foreach (var asmtype in assemblyTypes)
            {
                var fixture = new Fixture();
                var obj = new SpecimenContext(fixture).Resolve(asmtype);
                _handler.Error(new Login { BrandId = _brandId }, new Domain.Entities.Customer { CustomerId = It.IsAny<Guid>() }, (Exception) obj);
                if (obj is InvalidCredentialsException)
                    _loginRepository.Verify(v => v.ZZZ(It.IsAny<Guid>(), It.IsAny<int>()), Times.Once);
                else
                    _loginRepository.Verify(v => v.ZZZ(It.IsAny<Guid>(), It.IsAny<int>()), Times.Never);
            }
