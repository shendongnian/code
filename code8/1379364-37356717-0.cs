    var bytes = new Color[] { Color.Red, Color.Blue }
                    .Select(x => BitConverter.GetBytes(x.ToArgb()))
                    .SelectMany(x => x)
                    .ToArray();
    var hashCode = SHA256.Create().ComputeHash(bytes);
