    public class Header {
        List<Detail> _children = new List<Detail>();
        private class Detail {
           public Detail(Header header) {
               header._children.Add(this);
           }
        }
    }
