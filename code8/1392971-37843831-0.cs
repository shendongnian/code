using NUnit.Framework;
public class ParserTest {
    [Test]
    public void TestThatTwoPlayersAreInTestResponse()
    {
        string testResponse = "{ \"check\":\"success\", \"stats\":{ \"2\":{ \"rank\":1, \"score\":\"2000\", \"name\":\"Muhammad\" }, \"3\":{ \"rank\":1, \"score\":\"2000\", \"name\":\"Ramsay\" } } }";
        Assert.AreEqual(MiniJsonParsingExample.parseResponse(testResponse).Count, 2);
    }
}
