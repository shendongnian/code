    if (prompt != null)
    {
        var msg = context.MakeMessage();
        msg.Text = prompt.Prompt;
        msg.Attachments = prompt.Buttons.GenerateAttachments();
        await context.PostAsync(msg);
    }
    return prompt;
