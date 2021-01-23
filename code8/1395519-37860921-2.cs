    public delegate Task AsyncEventHandler<T>(object sender, T e);
    public event AsyncEventHandler<EventArgs> SaveClicked;
    private void btnSave_Click(object sender, EventArgs e)
    {
      if (SaveClicked != null)
        await Task.WhenAll(
          SaveClicked.GetInvocationList().Cast<AsyncEventHandler<T>>
              .Select(x => x(sender, e)));
    }
