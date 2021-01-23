        public void Append(student d)
        {
            var oldTail = FindTail();
            var newTail = new Node(d, oldTail);
            if (oldTail == null)
               head = newTail;
            else
               oldTail.link = newTail;
            // oh wait there is something missing here
            // hint: I ignored the size ... you should do something
            // about it
        }
