        using (var reader = System.IO.File.OpenText(ASSIGNMENT_TYPES_FILENAME))
        using (var jsonReader = new JsonTextReader(reader))
        {
            var serializer = JsonSerializer.CreateDefault();
            assignmentTypesList = serializer.Deserialize<List<AssignmentTypesLU>>(jsonReader);
        }
