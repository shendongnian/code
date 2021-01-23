    public sealed class LocationReader : ContentTypeReader<Location>
    {
        protected override Location Read(ContentReader input, Location existingInstance)
        {
            List<Texture2D> textures = input.ReadObject<List<Texture2D>>();
        }
    }
