    public IEnumerable<Member> GetMembers(Group group) {
         foreach(var member in group.MemberCollection) {
            yield return member;
         }
         foreach(var subGroup in group.GroupCollection) {
            foreach (var member in GetMembers(group)) {
                yield return member;
            }
         }
      }
