        public class Project
        {
            public virtual int Id { get; private set; }
            public string Title { get; set; }
            public void AssignMember(int userId, string someField, string someOtherField)
            {
                if (MemberAssignments.Any(x => x.UserId == userId))
                    throw new InvalidOperationException("User already assigned");
                MemberAssignments.Add(new ProjectMemberAssignment(Id, userId, someField, someOtherField));
            }
            // Other behavior methods.
            public virtual ICollection<ProjectMemberAssignment> { get; set; } 
        }
    
