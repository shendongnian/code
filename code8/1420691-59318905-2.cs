    public static async Task<bool> Initiate()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(URL);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.GetAsync("api/session");
                if (response.StatusCode != HttpStatusCode.OK)
                    return false;
                var sessionJson = await response.Content.ReadAsStringAsync();
                var session = JsonUtility.FromJson<Session>(sessionJson);
                Markers = session.Markers.ToDictionary(m => m.name, m => m);
                BillBoards = session.BillBoards.ToDictionary(b => b.name, b => b);
                Settings = session.Settings;
                return true;
            }
        }
