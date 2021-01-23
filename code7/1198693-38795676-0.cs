    class Project
    {
      public int ProjectId {get;set;}
      public string Title { get; set; }
      public DateTime CreatedAt { get; set; }
      public IList<ProjectMember> ProjectMembers { get; set; }
    }
    class ProjectMember
    {
      public int ProjectId {get;set;}
      public bool isConfirmed { get; set; }
      public string ProjectPosition { get; set; }
    }
