    private int[] GetIndices(string key, IList<IWebElement> objectList) {
      return objectList.Where(e => e.Text.Equals(key)).Select(e => objectList.IndexOf(e)).ToArray();
    }
    public void Method3(List<string> testingValues, IList<IWebElement> Element, IList<IWebElement> Element2) {
        if (testingValues.All(item => Element.Any(x => x.Text == item) || Element2.Any(y => y.Text == item))) {
            foreach(string key in testingValues) {
                Debug.WriteLine("Indices of {0} in first list: {1}", key, IndicesString(GetIndices(key, Element)));
                Debug.WriteLine("Indices of {0} in second list: {1}", key, IndicesString(GetIndices(key, Element2));
            }
        } else {
            Assert.Fail();
        }
    }
    private string IndicesString(int[] indices) {
        if (indices.Length == 0) return "NONE";
        StringBuilder sb = new StringBuilder();
        sb.Append("{");
        for(int i=0; i<indices.Length; i++) {
            if (i > 0) sb.Append(", ");
            sb.Append(indices[i]);
        }
        sb.Append("}");
        return sb.ToString();
    }
