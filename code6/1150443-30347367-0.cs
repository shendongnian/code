db.Songs.Where(x => x.SingerID == id).Select(song => new {
  Id,
  NAME,
  IMAGE,
  URL,
  SingerName = song.Singer.NAME
});
