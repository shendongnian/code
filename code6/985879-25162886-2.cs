    public void EndEdit()
        {
            IsEditing = false;
            repository.SaveMessages(this.Messages); 
        }
