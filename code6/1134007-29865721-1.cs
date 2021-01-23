    using System;
    using System.Collections.Generic;
    using System.Linq;
    class MyList<T> : IEnumerable<T> {
        class ListElement {
            public T content;
            public ListElement next;
        }
        ListElement head = null;
        public MyList() {
            head = null;
        }
        public MyList(IEnumerable<T> values)
            : this() {
            ListElement last = null;
            foreach(var v in values) {
                ListElement that = new ListElement { content = v };
                if(last != null) {
                    last.next = that;
                } else {
                    head = that;
                }
                last = that;
            }
        }
        public IEnumerator<T> GetEnumerator() {
            var current = head;
            while(current != null) {
                yield return current.content;
                current = current.next;
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }
