public string TelegramSendMessage(string apilToken, string destID, string text)
{
string urlString = $”https://api.telegram.org/bot{apilToken}/sendMessage?chat_id={destID}&text={text}";
WebClient webclient = new WebClient();
return webclient.DownloadString(urlString);
}
