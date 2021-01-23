    public class StoreDetailsDynamicNodeProvider 
    : DynamicNodeProviderBase 
    { 
    public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node) 
    {
        using (var storeDB = new MusicStoreEntities())
        {
            // Create a node for each album 
            foreach (var album in storeDB.Albums.Include("Genre")) 
            { 
                DynamicNode dynamicNode = new DynamicNode(); 
                dynamicNode.Title = album.Title; 
                dynamicNode.ParentKey = "Genre_" + album.Genre.Name; 
                dynamicNode.RouteValues.Add("id", album.AlbumId);
                yield return dynamicNode;
            }
        }
    } 
    }
