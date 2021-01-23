    client.ExecuteAsync(request, async (response) =>
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var list = await Task.Run( () => JsonConvert.DeserializeObject<List<MyObject>>(response.Content));
                tcs.SetResult(list);
            }
            else
            {
                MessageBox.Show("Error");
            }
        });
