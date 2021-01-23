    [TestClass]
    public class StringContentHeadersTests {
        [TestMethod]
        public void StringContent_Headers_Should_Match_When_Flatten_After() {
            var content = new StringContent("some json", Encoding.UTF8, "application/json");
            var dto = new ContentDto(content);
            var contentHeaders = content.Headers.Flatten();
            Assert.AreEqual(contentHeaders, dto.Headers);
        }
        [TestMethod]
        public void StringContent_Headers_Should_Match_When_Flatten_Before() {
            var content = new StringContent("some json", Encoding.UTF8, "application/json");
            var contentHeaders = content.Headers.Flatten();
            var dto = new ContentDto(content);
            Assert.AreEqual(contentHeaders, dto.Headers);
        }
        [TestMethod]
        public void StringContent_Headers_Should_Match_When_Flatten_Before_And_After() {
            var content = new StringContent("some json", Encoding.UTF8, "application/json");
            var dto = new ContentDto(content);
            var contentHeaders = content.Headers.Flatten();
            var dto1 = new ContentDto(content);
            Assert.AreEqual(contentHeaders, dto.Headers);
            Assert.AreEqual(contentHeaders, dto1.Headers);
        }
        public class ContentDto {
            public string ContentType { get; set; }
            public string Headers { get; set; }
            public object Data { get; set; }
            public ContentDto(HttpContent content) {
                Headers = content.Headers.Flatten();
                // rest of the setup
            }
        }
    }
    public static class HttpContentExtensions {
        public static string Flatten(this HttpHeaders headers) {
            var data = headers.ToDictionary(h => h.Key, h => string.Join("; ", h.Value))
                              .Select(kvp => string.Format("{0}: {1}", kvp.Key, kvp.Value));
            return string.Join(Environment.NewLine, data);
        }
    }
