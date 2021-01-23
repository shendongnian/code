            Regex regex = new Regex(@"^[A-Z][a-z]{6}\d{2}\W$");
            Assert.IsTrue(regex.IsMatch("Xabcdef99*"));
            Assert.IsTrue(regex.IsMatch("Xabcdef99$"));
            Assert.IsFalse(regex.IsMatch("Testeur333"));
            Assert.IsFalse(regex.IsMatch("userpcs12*"));
