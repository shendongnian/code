    // StringBuilder
    StringBuilder stringBuilder = new StringBuilder();
    foreach (var topic in user.Topics) {
       stringBuilder.Append(topic.Code);
       stringBuilder.Append(", ");
    }
    stringBuilder.length--;
    codes = stringBuilder.ToString();
