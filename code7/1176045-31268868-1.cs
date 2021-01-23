    [Authorize]
    public void RegisterAsTeamMember()
    {
          if (!IDs.Any(u => u == Context.ConnectionId))
          {
               IDs.Remove(Context.ConnectionId);
          }
    }
