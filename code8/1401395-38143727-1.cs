    IEnumerable<TDto> GetDeserializedJson<TDto>(string pathToJsonFile) where TDto : DtoBaseClass
    {
         IEnumerable<TDto> result;
         using (TextReader file = File.OpenText(pathToJsonFile)) 
         {
              result = JsonSerializer.DeserializeFromReader<IEnumerable<TDto>>(file);
         }
         return result.OfType<TDto>.Where(x => x != null);
    }
