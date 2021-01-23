    var sig = this._entities.SignalMetaDatas
                            .SingleOrDefault(signal => signal.SignalId == signalId);
    var group = this._entities.Groups
                              .SingleOrDefault(g => g.groupId == groupId);
    if (sig != null) 
    {
        sig.Group = group;
        this._entities.SaveChanges();
    }
