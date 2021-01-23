    public IEnumerable<Member> GetMembers() {
         var stack = new Stack<Group>();
         stack.Push(this);
         while (stack.Count > 0) {
             var group = stack.Pop();
             foreach(var member in group.MemberCollection) {
                yield return member;
             }
             foreach(var subGroup in group.GroupCollection) {
                stack.Push(subGroup);
             }
         }
      }
