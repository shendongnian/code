    public interface IGitHubService  
    {
      [Get("/users/{user}/repos")]
      Task<List<Repo>> ListRepos(string user);
    }
