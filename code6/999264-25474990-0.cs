        vkResponse[] vkResponses = JsonConvert.DeserializeObject<vkResponse[]>(array.ToString());
        if (vkResponses == null)
            throw new JsonException();
        int [] ids = new int[vkResponses.Length];
        for (int i = 0; i < vkResponses.Length; i++)
        {
            ids[i] = vkResponses[i].Id;
        }
