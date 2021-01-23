    public void UpdateItemTitle(string agendaId, string itemId, string title){
        var filter = Builders<TempAgenda>.Filter.Where(x => x.AgendaId == agendaId && x.Items.Any(i => i.Id == itemId));
        var update = Builders<TempAgenda>.Update.Set(x => x.Items[-1].Title, title);
        var result = _collection.UpdateOneAsync(filter, update).Result;
    }
