    public override void Execute(CommandContext context)
    {
      Assert.ArgumentNotNull((object) context, "context");
      if (context.Items.Length != 1)
        return;
      Item item = context.Items[0];
      ...
    }
