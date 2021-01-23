    private Image DeepCopy(Image other)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(ms, other);
                    ms.Position = 0;
                    return (Image)formatter.Deserialize(ms);
                }
            }
.
    Image tempImg = DeepCopy(img);
