    public override CommandState QueryState(CommandContext context)
    {
      Assert.ArgumentNotNull((object) context, "context");
      if (context.Items.Length != 1)
        return CommandState.Hidden;
      Item item = context.Items[0];
      if (item.TemplateID == ...) 
        return CommandState.Enabled;
      return CommandState.Hidden;
    }
